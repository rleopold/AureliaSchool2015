import {HttpClient} from 'aurelia-http-client';

var url = window.location.origin + '/api/teachers';

export class TeacherService {
    static inject() {return [HttpClient];}

    constructor(http) {
        this.http = http.request.withHeader('Content-Type', 'application/json');
    }

    getTeachers() {
        return this.http.get(url);
    }

    getTeacher(id) {

    }

    insertTeacher(data) {
        return this.http.post(url,data);
    }

    updateTeacher(data) {

    }

    deleteTeacher(id) {
        return this.http.delete(url + '/' + id);
    }
}