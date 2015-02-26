import {Router} from 'aurelia-router';
import bootstrap from 'bootstrap';

export class App {
    static inject() { return [Router]; }
    constructor(router) {
        this.router = router;
        this.router.configure(config => {
            config.title = 'Aurelia';
            config.map([
              { route: ['','welcome'],  moduleId: 'welcome',      nav: true, title:'Welcome' },
              { route: 'students', modeuleId: 'students', nav: true, title: 'Students'},
              { route: 'teachers', modeuleId: 'teachers', nav: true, title: 'Teachers'},
              { route: 'classes',  modeuleId: 'classes',  nav: true, title: 'Classes'}
            ]);
        });
    }
}