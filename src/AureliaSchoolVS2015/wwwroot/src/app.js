import {Router} from 'aurelia-router';
import bootstrap from 'bootstrap';

export class App {
    static inject() { return [Router]; }
    constructor(router) {
        this.router = router;
        this.router.configure(config => {
            config.title = 'Aurelia';
            config.map([
              { route: ['','welcome'],  moduleId: './modules/welcome',      nav: true, title:'Welcome' },
              { route: 'students', moduleId: './modules/students', nav: true, title: 'Students'},
              { route: 'teachers', moduleId: './modules/teachers', nav: true, title: 'Teachers'},
              { route: 'classes',  moduleId: './modules/classes',  nav: true, title: 'Classes'}
            ]);
        });
    }
}