import {HttpClient} from 'aurelia-http-client';

var url = window.location.origin + '/api/students';

export class StudentService {
    static inject() {return [HttpClient];}

    constructor(http) {
        this.http = http.request.withHeader('Content-Type', 'application/json');
    }

    getStudents() {
        return this.http.get(url);
    }

    getStudent(id) {

    }

    insertStudent(data) {
        return this.http.post(url,data);
    }

    updateStudent(data) {

    }

    deleteStudent(id) {
        return this.http.delete(url + '/' + id);
    }
}