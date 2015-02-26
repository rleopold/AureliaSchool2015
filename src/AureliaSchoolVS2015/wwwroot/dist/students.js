import {StudentService} from './studentService';

var url = window.location.origin + '/api/students';

export class Students {
    static inject() {return [StudentService];}
    
    constructor(api) {
        this.students = [];
        this.api = api;
        this.newStudent = {};
        this.showAdd = false;
    }

    activate() {
        return this.api.getStudents().then(response => {
            this.students = response.content;
        });
    }

    clickAdd() {
        this.showAdd = !this.showAdd;
    }

    addStudent(data) {
        this.api.insertStudent(data).then(response => {
            this.students.push(response.content);
            this.showAdd = false;
            this.newStudent = {};
        });
    }

    deleteStudent(idx) {
        console.log(idx);
        var s = this.students[idx];
        this.api.deleteStudent(s.Id).then(response => {
            this.students.splice(idx,1);
        })
    }
}