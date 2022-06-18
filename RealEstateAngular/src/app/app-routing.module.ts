import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListPropertyComponent } from './list-property/list-property.component';
import { LoginComponent } from './login/login.component';
import { MainLayoutComponent } from './main-layout/main-layout.component';
import { PropertiesComponent } from './properties/properties.component';
import { PropertyComponent } from './property/property.component';
import { RentalsListComponent } from './rentals-list/rentals-list.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  {
    path: '',
    component: MainLayoutComponent,
    children: [
      { path: 'properties', component: PropertiesComponent },
      { path: 'list-property', component: ListPropertyComponent },
      { path: 'property/:propertyId', component: PropertyComponent },
      { path: 'contracts', component: RentalsListComponent },
    ]
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
