import {StudentService} from './services/studentService';
import {Notify} from './services/notify';

export class Students {
    static inject() {return [StudentService, Notify];}
    
    constructor(api, notify) {
        this.students = [];
        this.api = api;
        this.newStudent = {};
        this.showAdd = false;
        this.notify = notify;
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
        this.api.insertStudent(data)
            .then(response => {
                this.students.push(response.content);
                this.showAdd = false;
                this.newStudent = {};
                this.notify.success("Added a new student");
            })
            .catch(response => {
                this.notify.error("Add student failed");
                console.log(response);
            });
    }

    deleteStudent(idx) {
        console.log(idx);
        var s = this.students[idx];
        this.api.deleteStudent(s.Id)
            .then(response => {
                this.students.splice(idx,1);
                this.notify.success("Deleted a student")
            })
            .catch(response => {
                this.notify.error("Failed to delete student");
                console.log(response);
            });
    }
}