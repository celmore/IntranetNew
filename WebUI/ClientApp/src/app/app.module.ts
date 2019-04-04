import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { ILSComponent } from './home/ils.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { ReportsComponent } from './reports/reports.component';
import { DictionaryComponent } from './dictionary/dictionary.component';
import { AviationRelatedMfrsComponent } from './aviationrelatedmfrs/aviationrelatedmfrs.component';

import { AviationRelatedPubsComponent } from './AviationRelatedPubs/AviationRelatedPubs.component';
import { AirwayBillTrackerComponent } from './AirwayBillTracker/AirwayBillTracker.component';
import { generalreferencesComponent } from './GeneralRef/generalrefernces.component';
import { OtherResourcescomponent } from './OtherResources/OtherResources.component';
import { TravelHelpcomponent } from './TravelHelp/TravelHelp.component';
import { accountscomponent } from './Accounts/accounts.component';
import { QA_Inspestioncomponent } from './QA/QA.component';
import { masterlistcomponent } from './MasterProcedureList/MasterProcedureList.component';
import { misComponent } from './mis/mis.component';
import { bldgengcomponent } from './bldgeng/bldgeng.component';
import { Payrollcomponent } from './ERC/Payroll/payroll.component';
import { WellnessComponent } from './ERC/wellness.component';
import { ManagersComponent } from './ERC/Payroll/managers.component';
import { quickFixesComponent } from './mis/quickFixes.component';
import { Purchasecomponent } from './Purchasing/Purchase.component';
import { RawMatcomponent } from './Purchasing/rawmat.component';
import { shippingcomponent } from './Shipping/shipping.component';
import { salecomponent } from './Sale/Sale.component';
import { CustomerServicecomponent } from './Customer Service/CustomerService.component';
<<<<<<< HEAD
//import { BusinessDevelopmentcomponent } from './BusinessDevelopment/BusinessDevelopment.component';
=======
import { BusinessDevelopmentcomponent } from './BusinessDevelopment/BusinessDevelopment.component';
>>>>>>> intranet updates
import { Engineeringcomponent } from './Engineers/Engineering.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    ReportsComponent,
    DictionaryComponent,

    AviationRelatedMfrsComponent,
    AviationRelatedPubsComponent,
    AirwayBillTrackerComponent,
    generalreferencesComponent,
    OtherResourcescomponent,
    TravelHelpcomponent,
    accountscomponent,
    QA_Inspestioncomponent,
    misComponent,
    bldgengcomponent,
    masterlistcomponent,
    Payrollcomponent,
    ILSComponent,
    WellnessComponent,
    ManagersComponent,
    quickFixesComponent,
    Purchasecomponent,
    RawMatcomponent,
    shippingcomponent,
    salecomponent,
    CustomerServicecomponent,
<<<<<<< HEAD
    //BusinessDevelopmentcomponent,
=======
    BusinessDevelopmentcomponent,
>>>>>>> intranet updates
    Engineeringcomponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: 'home', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'reports', component: ReportsComponent },
      { path: 'dictionary', component: DictionaryComponent },
      { path: 'aviationrelatedmfrs', component: AviationRelatedMfrsComponent },
      { path: 'AviationRelatedPubs', component: AviationRelatedPubsComponent },
      { path: 'AirwayBillTracker', component: AirwayBillTrackerComponent },
      { path: 'GeneralRef', component: generalreferencesComponent },
      { path: 'OtherResources', component: OtherResourcescomponent },
      { path: 'TravelHelp', component: TravelHelpcomponent },
      { path: 'Accounts', component: accountscomponent },
      { path: 'QA', component: QA_Inspestioncomponent },
      { path: 'mis', component: misComponent },
      { path: 'bldgeng', component: bldgengcomponent },
      { path: 'MasterProcedureList', component: masterlistcomponent },
      { path: 'Payroll', component: Payrollcomponent },
      { path: 'ILS', component: ILSComponent },
      { path: 'Wellness', component: WellnessComponent },
      { path: 'Managers', component: ManagersComponent },
      { path: 'quickFixes', component: quickFixesComponent },
      { path: 'Purchasing', component: Purchasecomponent },
      { path: 'RawMat', component: RawMatcomponent },
      { path: 'shipping', component: shippingcomponent },
      { path: 'Sale', component: salecomponent },
      { path: 'CustomerService', component: CustomerServicecomponent },
<<<<<<< HEAD
      //{ path: 'BusinessDevelopment', component: BusinessDevelopmentcomponent },
=======
      { path: 'BusinessDevelopment', component: BusinessDevelopmentcomponent },
>>>>>>> intranet updates
      { path: 'Engineering', component: Engineeringcomponent },
      { path: '**', redirectTo: 'home' }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
