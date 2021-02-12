import { RouterModule, Routes } from '@angular/router';
import { ModuleWithProviders } from '@angular/core';

import { ChangePassComponent } from './app/change-pass/change-pass.component';

const routes: Routes = [
  { path: 'changepass', component: ChangePassComponent }
];
export const routing: ModuleWithProviders = RouterModule.forRoot(routes);
