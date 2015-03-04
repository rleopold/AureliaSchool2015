import {HttpClient} from 'aurelia-http-client';

var url = window.location.origin + '/api/classes';

export class ClassService {
    static inject() {return [HttpClient];}

    constructor(http) {
        this.http = http.request.withHeader('Content-Type', 'application/json');
    }

    getClasses() {
        return this.http.get(url);
    }

    getClass(id) {

    }

    insertClass(data) {
        return this.http.post(url,data);
    }

    updateClass(data) {

    }

    deleteClass(id) {
        return this.http.delete(url + '/' + id);
    }
}