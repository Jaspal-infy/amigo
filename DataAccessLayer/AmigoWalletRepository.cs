using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Models;
using System.Linq;

namespace DataAccessLayer
{
    public class AmigoWalletRepository
    {
        DEC20USBATCH1MSAGROUP1DBContext context;

        public AmigoWalletRepository()
        {
            context = new DEC20USBATCH1MSAGROUP1DBContext();
        }

        public List<User> test()
        {
            var merchant = (from x in context.User select x).ToList();

            return merchant;
        }

        public bool changepassword(string eId, string pass)
        {

            User user = null;
            bool results = false;
            bool changed = false;
            try
            {
                user = (from u in context.User where u.EmailId == eId select u).First();
            }
            catch(Exception ex)
            {
                user = null;
            }


            if (user != null)
            {
                results = user.Password == pass;
            }

            if (user != null && results == false)
            {
                changed = true;
            }
            //now that we know password can be changed time to update it.
            if (changed)
            {
                user.Password = pass;
                context.SaveChanges();
            }
            return changed;



        }

        public string forgotpassword(string eId)
        {
            User user = null;
            string status = "Email not found";
            try
            {
                user = (from u in context.User where u.EmailId == eId select u).First();
            }
            catch(Exception ex)
            {
                user = null;
            }

            //if user is found then when have to generate the otp
            if(user != null)
            {
                Otp newOtp = new Otp();
                Random rand = new Random();
                //stackoverflow example
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                string otpCode = new string(Enumerable.Repeat(chars, 6)
                        .Select(s => s[rand.Next(s.Length)]).ToArray());

                DateTime current = DateTime.Now;
                DateTime otpTime = current.AddMinutes(5);

                //now set the values in the newOtp 
                newOtp.Otpvalue = otpCode;
                newOtp.ReferenceId = eId;
                newOtp.ExpiryDateTime = otpTime;
                newOtp.OtppurposeId = 2;
                newOtp.IsValid = true;
                context.Otp.Add(newOtp);
                context.SaveChanges();

                status = otpCode;
            }

            return status;
        }

        public string givePasswordOtp(string eId, string otpCode)
        {
            string results = "OTP Or Email is invalid";
            User user = null;
            Otp otp = null;
            bool status = (from o in context.Otp where o.Otpvalue == otpCode && o.ReferenceId == eId select o).Any();

            if (status)
            {
                //now that we found the match we check if time is valid
                try
                {
                    otp = (from o in context.Otp where o.ReferenceId == eId && o.Otpvalue == otpCode select o).First();
                }
                catch(Exception ex)
                {
                    otp = null;
                }

                if(otp.ExpiryDateTime > DateTime.Now)
                {
                    try
                    {
                        user = (from u in context.User where u.EmailId == eId select u).First();
                    }
                    catch(Exception ex)
                    {
                        user = null;
                    }

                    results = user.Password;
                }

            }

            return results;

        }

        public string paymentOfBills(string eId, int paymentAmount, string merchantName)
        {
            string status = "Email not found or Merchant name not found";
            var userTrans = (from u in context.UserTransaction where u.EmailId == eId select u).ToList();
            decimal amount = 0;
            if (userTrans.Count() != 0)
            {
                foreach (var x in userTrans)
                {
                    //now we need the amount for which the wallet has.
                    if (x.PaymentTypeId.Equals(3) && x.StatusId == 1)
                    {
                        amount += x.Amount;
                    }
                    else if (x.PaymentTypeId.Equals(5) && amount > 0 && x.StatusId == 1)
                    {
                        amount = amount - x.Amount;
                    }
                }
            }
            //now to add merchant transaction
            Merchant merch = null;
            try
            {
                merch = (from m in context.Merchant where m.Name == merchantName select m).First();
            }
            catch (Exception ex)
            {
                merch = null;
            }

            if (paymentAmount <= amount && merch != null)
            {

                UserTransaction uT = new UserTransaction();
                uT.EmailId = eId;
                uT.Amount = paymentAmount;
                uT.TransactionDateTime = DateTime.Now;
                uT.PaymentTypeId = 5;
                uT.Remarks = "Bill";
                uT.Info = "Customer payment of bill";
                uT.StatusId = 1;
                Int16 point =0;
                if (amount > 5)
                    point = 5;
                uT.PointsEarned = point;
                uT.IsRedeemed = false;

                context.UserTransaction.Add(uT);

                MerchantTransaction mT = new MerchantTransaction();
                mT.EmailId = merch.EmailId;
                mT.Amount = paymentAmount;
                mT.TransactionDateTime = DateTime.Now;
                mT.PaymentTypeId = 5;
                mT.Remarks = "pmt recieved";
                mT.Info = "Payment from customer";
                mT.StatusId = 1;
                context.MerchantTransaction.Add(mT);
                context.SaveChanges();
                string pr = Convert.ToString(point);
                status = "Payment was completed and you received " + pr + " reward points";
            }
            else if(paymentAmount > amount && merch!= null && userTrans.Count() != 0)
            {
                UserTransaction uT = new UserTransaction();
                uT.EmailId = eId;
                uT.Amount = paymentAmount;
                uT.TransactionDateTime = DateTime.Now;
                uT.PaymentTypeId = 5;
                uT.Remarks = "Denied";
                uT.Info = "Customer payment of bill denied";
                uT.StatusId = 5;
                uT.PointsEarned = 0;
                uT.IsRedeemed = false;

                context.UserTransaction.Add(uT);
                context.SaveChanges();
                status = "Payment denied not enough funds";
            }

            return status;
        }
       
        public string[] merchantName()
        {
            var merchant = (from x in context.Merchant select x.Name).ToArray();

            return merchant;
        }
    }
}
