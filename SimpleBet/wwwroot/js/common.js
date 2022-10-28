window.ShowToastr = (type, message, header) => {
    if (type === "success") {
        if (header == null) {
            header = "Operacija uspješna";
        }
        toastr.success(message, header, { timeOut: 8000, positionClass: "toast-bottom-right" });
    }
    if (type === "info") {
        if (header == null) {
            header = "Info";
        }
        toastr.info(message, header, { timeOut: 8000, positionClass: "toast-bottom-right" });
    }
    if (type === "warning") {
        if (header == null) {
            header = "Upozorenje";
        }
        toastr.warning(message, header, { timeOut: 8000, positionClass: "toast-bottom-right" });
    }
    if (type === "error") {
        if (header == null) {
            header = "Dogodila se greška";
        }
        toastr.error(message, header, { timeOut: 8000, positionClass: "toast-bottom-right" });
    }
}

function ShowDeleteConfirmationModal() {
    $('#deleteConfirmationModal').modal('show');
}

function HideDeleteConfirmationModal() {
    $('#deleteConfirmationModal').modal('hide');
}