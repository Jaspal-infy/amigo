import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { ChangepasswordService } from '../changepassword.service';
@Component({
  //selector: 'app-change-pass',
  templateUrl: './change-pass.component.html',
  styleUrls: ['./change-pass.component.css']
})
export class ChangePassComponent implements OnInit {

  changeForm: FormGroup;


  constructor(private formBuilder: FormBuilder, private _changepassService: ChangepasswordService) { }

  SubmitForm(form: FormGroup) {
    this._changepassService.changepass(form.value.emailId, form.value.password).subscribe()
    console.log(form.value.emailId, form.value.password);
  }
  ngOnInit() {
    this.changeForm = this.formBuilder.group({
      emailId: [''],
      password: ['',
        [Validators.required, Validators.minLength(8), Validators.maxLength(20), Validators.pattern("(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!#$%^&*()])")]
      ]
    })
  }

}
