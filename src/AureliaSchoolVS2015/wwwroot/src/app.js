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
              { route: 'students', moduleId: 'students', nav: true, title: 'Students'},
              { route: 'teachers', moduleId: 'teachers', nav: true, title: 'Teachers'},
              { route: 'classes',  moduleId: 'classes',  nav: true, title: 'Classes'}
            ]);
        });
    }
}