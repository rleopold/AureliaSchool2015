import {TeacherService} from '../services/teacherService';
import {Notify} from '../services/notify';

export class Teachers {
    static inject() {return [TeacherService, Notify];}

    constructor(api, notify) {
        this.api = api;
        this.notify = notify;

        this.newTeacher = {};
        this.teachers = [];
        this.showAdd = false;

    }

    activate() {
        return this.api.getTeachers()
            .then(response => {
                this.teachers = response.content;
            })
            .catch(response => {
                console.log(response);
                notify.error("Failed to get techers.");
            });
    }

    clickAdd() {
        this.showAdd = !this.showAdd;
    }

    addTeacher(data) {
        this.api.insertTeacher(data)
            .then(response => {
                this.teachers.push(response.content);
                this.showAdd = false;
                this.newTeacher = {};
                this.notify.success("New teacher added");
            })
            .catch(response => {
                console.log(response);
                this.notify.error("Failed to add teacher.");
            });
    }

    deleteTeacher(idx) {
        var t = this.teachers[idx];
        this.api.deleteTeacher(t.Id)
            .then(response => {
                this.teachers.splice(idx,1);
                this.notify.success("Deleted Teacher");
            })
            .catch(response => {
                console.log(response);
                this.notify.error("Failed to delete teacher.");
            });
    }
}