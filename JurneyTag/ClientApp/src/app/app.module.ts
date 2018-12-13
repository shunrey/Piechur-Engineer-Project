import { Quill } from 'node_modules/acorn';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {MatToolbarModule, MatMenuModule, MatButtonModule, MatExpansionModule, MatIconModule, MatInputModule, MatStepperModule, MatRadioModule, MatDividerModule, MatGridListModule} from '@angular/material';
import { CityListComponent } from './city-list/city-list.component';
import { CityNewComponent } from './city-new/city-new.component';
import { FormsModule } from '@angular/forms';
import { FroalaEditorModule, FroalaViewModule } from 'angular-froala-wysiwyg';
import {EditorModule} from 'primeng/editor';
import { QuillModule } from 'ngx-quill';
import { AngularFontAwesomeModule } from 'angular-font-awesome';
import { HttpClientModule } from '@angular/common/http';
import { ImageUploadModule } from "angular2-image-upload";
import { MatFileUploadModule } from 'angular-material-fileupload';



@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
    CityListComponent,
    CityNewComponent
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
    MatRadioModule,
    FormsModule,
    EditorModule,
    AngularFontAwesomeModule,
    QuillModule,
    FroalaEditorModule.forRoot(),
    FroalaViewModule.forRoot(),
    MatDividerModule,
    MatGridListModule,
    HttpClientModule,
    ImageUploadModule.forRoot(),
    MatFileUploadModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
