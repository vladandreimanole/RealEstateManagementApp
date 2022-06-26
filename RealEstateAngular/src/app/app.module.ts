import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AuthGuard } from './guards/auth.guard';
import { HomeComponent } from './home/home.component';
import { JwtModule } from "@auth0/angular-jwt";
import { SwitchModule } from '@syncfusion/ej2-angular-buttons';
import { GridModule } from '@syncfusion/ej2-angular-grids';
import { MaterialModule } from './material/material.module';
import { MainLayoutComponent } from './main-layout/main-layout.component';
import { ListPropertyComponent } from './list-property/list-property.component';
import { ReactiveFormsModule } from '@angular/forms';
import { UploaderModule } from '@syncfusion/ej2-angular-inputs';
import { RouterModule } from '@angular/router';
import { PropertiesComponent } from './properties/properties.component';
import { CarouselModule } from "@syncfusion/ej2-angular-navigations";
import { DialogAnimationsExampleDialog, PropertyComponent } from './property/property.component';
import { DialogModule } from '@syncfusion/ej2-angular-popups';
import { MatButtonModule } from "@angular/material/button";
import { RentalsListComponent } from './rentals-list/rentals-list.component';
import { PasswordResetComponent } from './password-reset/password-reset.component';
import { TenantRentalsComponent } from './tenant-rentals/tenant-rentals.component';
import { ContractComponent } from './contract/contract.component';
import { RichTextEditorAllModule } from '@syncfusion/ej2-angular-richtexteditor';
import { ChartAllModule } from '@syncfusion/ej2-angular-charts';
import { DateTimeService, LineSeriesService, DateTimeCategoryService, StripLineService} from '@syncfusion/ej2-angular-charts';

export function tokenGetter() { 
  return localStorage.getItem("jwt"); 
}

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    HomeComponent,
    MainLayoutComponent,
    ListPropertyComponent,
    PropertiesComponent,
    PropertyComponent,
    DialogAnimationsExampleDialog,
    RentalsListComponent,
    PasswordResetComponent,
    TenantRentalsComponent,
    ContractComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        allowedDomains: ["localhost:7243"],
        disallowedRoutes: []
      }
    }),
    SwitchModule,
    GridModule,
    MaterialModule,
    ReactiveFormsModule,
    UploaderModule,
    RouterModule,
    CarouselModule,
    DialogModule,
    MatButtonModule,
    RichTextEditorAllModule,
    ChartAllModule
  ],
  providers: [AuthGuard, DateTimeService, LineSeriesService, DateTimeCategoryService, StripLineService],
  bootstrap: [AppComponent]
})
export class AppModule { }
