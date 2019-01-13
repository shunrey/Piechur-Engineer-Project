import { Quill } from 'node_modules/acorn';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {MatToolbarModule, MatMenuModule, MatButtonModule, MatExpansionModule, MatIconModule, MatInputModule, MatStepperModule, MatRadioModule, MatDividerModule, MatGridListModule, MatCardModule, MatDialogModule, MatSnackBarModule, MatSelectModule, MatTableModule, MatListModule, MatDatepickerModule, MatNativeDateModule, MAT_DATE_LOCALE, MAT_DATE_FORMATS, NativeDateModule, MatYearView} from '@angular/material';
import { CityListComponent } from './city-list/city-list.component';
import { CityNewComponent } from './city-new/city-new.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FroalaEditorModule, FroalaViewModule } from 'angular-froala-wysiwyg';
import {EditorModule} from 'primeng/editor';
import { QuillModule } from 'ngx-quill';
import { AngularFontAwesomeModule } from 'angular-font-awesome';
import { HttpClientModule } from '@angular/common/http';
import { ImageUploadModule } from "angular2-image-upload";
import { MatFileUploadModule } from 'angular-material-fileupload';
import { CityDetailComponent } from './city-detail/city-detail.component';
import { RouterModule, Routes } from '@angular/router';
import { MainComponent } from './main/main.component';
import { AccomodationNewComponent } from './accomodation-new/accomodation-new.component';
import { AccomodationRoomComponent } from './accomodation-room/accomodation-room.component';
import { AccomodationAlimentationComponent } from './accomodation-alimentation/accomodation-alimentation.component';
import { AccomodationListComponent } from './accomodation-list/accomodation-list.component';
import { AccomodationDetailComponent } from './accomodation-detail/accomodation-detail.component';
import { AttractionListComponent } from './attraction-list/attraction-list.component';
import { AttractionNewComponent } from './attraction-new/attraction-new.component';
import { AttractionDetailComponent } from './attraction-detail/attraction-detail.component';
import { OffertNewComponent } from './offert-new/offert-new.component';
import { OffertAttractionDetailComponent } from './offert-attraction-detail/offert-attraction-detail.component';



@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
    CityListComponent,
    CityNewComponent,
    CityDetailComponent,
    MainComponent,
    AccomodationNewComponent,
    AccomodationRoomComponent,
    AccomodationAlimentationComponent,
    AccomodationListComponent,
    AccomodationDetailComponent,
    AttractionListComponent,
    AttractionNewComponent,
    AttractionDetailComponent,
    OffertNewComponent,
    OffertAttractionDetailComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    MatMenuModule,
    MatToolbarModule,
    MatButtonModule,
    MatExpansionModule,
    MatIconModule,
    MatInputModule,
    MatStepperModule,
    MatSnackBarModule,
    MatRadioModule,
    FormsModule,
    EditorModule,
    AngularFontAwesomeModule,
    QuillModule,
    FroalaEditorModule.forRoot(),
    FroalaViewModule.forRoot(),
    MatDividerModule,
    MatGridListModule,
    MatSelectModule,
    MatTableModule,
    HttpClientModule,
    ImageUploadModule.forRoot(),
    MatFileUploadModule,
    MatCardModule,
    MatDialogModule,
    MatListModule,
    FormsModule,
    ReactiveFormsModule,
    MatDatepickerModule,
    NativeDateModule,
    MatListModule,
    MatNativeDateModule,
    RouterModule.forRoot([
      {path: '', component:MainComponent},
      {path: 'addCity', component: CityNewComponent},
      {path: 'listCity', component: CityListComponent},
      {path: 'listAccd', component: AccomodationListComponent},
      {path: 'listAttr', component: AttractionListComponent},
      {path: 'addAccomodation', component: AccomodationNewComponent},
      {path: 'addAttraction', component: AttractionNewComponent},
      {path: 'addOffert', component: OffertNewComponent}
    ]),
  ],
  providers: [
    { provide: MAT_DATE_LOCALE, useValue: 'pl-PL' },
  ],
  entryComponents: [CityDetailComponent, AccomodationRoomComponent, AccomodationAlimentationComponent,
                    AccomodationDetailComponent, AttractionDetailComponent, OffertAttractionDetailComponent],
  bootstrap: [AppComponent]
})
export class AppModule { }


