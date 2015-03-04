import {ClassService} from '../services/classService';
import {TeacherService} from '../services/teacherService';
import {Notify} from '../services/notify';

export class Classes {
    static inject() {return [ClassService, TeacherService, Notify];}

    constructor(classApi, teacherApi, notify) {

        this.classApi = classApi;
        this.teacherApi = teacherApi;
        this.notify = notify;

        this.classes = [];
        this.teachers = [];
        this.newClass = {};
        this.showAdd = false;
    }

    activate() {
        this.classApi.getClasses()
            .then(response => {
                this.classes = response.content;
            });
        this.teacherApi.getTeachers()
            .then(response => {
                this.teachers = response.content;
            });
    }

    addClass(data) {
        this.classApi.insertClass(data)
        .then(response => {
            this.classes.push(response.content);
            this.showAdd = false;
            this.newClass = {};
            this.notify.success("New class added");
        })
        .catch(response => {
            console.log(response);
            this.notify.error("Failed to add class.");
        });
    }

    deleteClass(idx) {
        var c = this.classes[idx];
        this.classApi.deleteClass(c.Id)
        .then(response => {
            this.classes.splice(idx,1);
            this.notify.success("Deleted class");
        })
        .catch(response => {
            console.log(response);
            this.notify.error('Failed to delete class');
        });
    }

    clickAdd() {
        this.showAdd = !this.showAdd;
    }
}