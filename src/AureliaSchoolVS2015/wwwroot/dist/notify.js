import toastr from 'toastr';

export class Notify {

    success(message) {
        toastr.success(message);
    }

    error(message) {
        toastr.error(message);
    }
}