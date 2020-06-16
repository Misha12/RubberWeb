import { Component } from '@angular/core';

@Component({
    selector: 'app-loader',
    template: '<div class="loader-img"><img src="/assets/duck.gif" width="256" height="256" /></div><h1>Načítání...</h1>',
    styles: [
        '.loader-img { display: flex; justify-content: center; }',
        'img { display: block; }',
        'h1 { font-weight: 100; color: #99AAB5; text-align: center }'
    ]
})
export class LoaderComponent { }
