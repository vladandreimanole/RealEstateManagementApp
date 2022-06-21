import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContractComponent } from './contract/contract.component';
import { AuthGuard } from './guards/auth.guard';
import { ListPropertyComponent } from './list-property/list-property.component';
import { LoginComponent } from './login/login.component';
import { MainLayoutComponent } from './main-layout/main-layout.component';
import { PasswordResetComponent } from './password-reset/password-reset.component';
import { PropertiesComponent } from './properties/properties.component';
import { PropertyComponent } from './property/property.component';
import { RentalsListComponent } from './rentals-list/rentals-list.component';
import { TenantRentalsComponent } from './tenant-rentals/tenant-rentals.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'app-password-reset', component: PasswordResetComponent},
  {
    path: '',
    component: MainLayoutComponent, canActivate:[AuthGuard],
    children: [
      { path: 'properties', component: PropertiesComponent,canActivate: [AuthGuard]},
      { path: 'list-property', component: ListPropertyComponent,canActivate: [AuthGuard] },
      { path: 'property/:propertyId', component: PropertyComponent,canActivate: [AuthGuard] },
      { path: 'rentals-list', component: RentalsListComponent, canActivate: [AuthGuard] },
      { path: 'my-rentals', component: TenantRentalsComponent, canActivate: [AuthGuard] },
      { path: 'contract/:contractId', component: ContractComponent, canActivate: [AuthGuard] }
    ]
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
