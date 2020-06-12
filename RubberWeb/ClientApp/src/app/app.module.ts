import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { NgbPaginationModule } from '@ng-bootstrap/ng-bootstrap';
import { AppComponent } from './app.component';
import { APP_BASE_HREF, PlatformLocation } from '@angular/common';
import { MainComponent } from './main/main.component';
import { LoaderComponent } from './loader.component';
import { NumberFormatPipe } from 'src/services/number-format.pipe';

@NgModule({
    declarations: [
        AppComponent,
        MainComponent,
        LoaderComponent,
        NumberFormatPipe
    ],
    imports: [
        BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
        HttpClientModule,
        FormsModule,
        NgbPaginationModule
    ],
    providers: [
        {
            provide: APP_BASE_HREF,
            useFactory: (platform: PlatformLocation) => platform.getBaseHrefFromDOM(),
            deps: [PlatformLocation]
        }
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
