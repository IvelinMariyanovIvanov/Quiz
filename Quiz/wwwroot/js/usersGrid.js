let dataTable;

$(document).ready(function () {
    createUsersTable();
});

function createUsersTable() {
    dataTable = $('#usersGridTable').DataTable({
        ajax: {
            url: '/Users/GetAllUsersAPI'
        },
        columns: [
            { data: 'fullName' },
            { data: 'email' },
            {
                data: { id: "id", lockoutEnd: "lockoutEnd" },
                render: function (data) {

                    let today = new Date().getTime();
                    let lockout = new Date(data.lockoutEnd).getTime();

                    if (lockout > today) {
                        return `<div class="d-flex justify-content-around">
                                    <a onClick=LockOrUnlockUser('${data.id}') class="btn btn-outline-success">
                                        <i class="bi bi-unlock-fill"></i>
                                        UnLock
                                    </a>

                                      <a onClick=DeleteUser('/Users/DeleteUserAPI?id=${data.id}')
                                        class="btn btn-outline-danger">
                                        <i class="bi bi-trash3"></i>
                                        Delete
                                    </a>

                                    <a href="/Users/EditUser?id=${data.id}"
                                        class="btn btn-outline-primary">
                                        <i class="bi bi-pencil-square"></i>
                                        Edit
                                    </a>
                                </div>`
                    }
                    else {
                        return `<div class="d-flex justify-content-around">
                                    <a onClick=LockOrUnlockUser('${data.id}') class="btn btn-outline-danger">
                                       <i class="bi bi-lock-fill"></i>
                                        Lock
                                    </a>

                                   <a onClick=DeleteUser('/Users/DeleteUserAPI?id=${data.id}')
                                        class="btn btn-outline-danger">
                                        <i class="bi bi-trash3"></i>
                                        Delete
                                    </a>

                                    <a href="/Users/EditUser?id=${data.id}"
                                        class="btn btn-outline-primary">
                                        <i class="bi bi-pencil-square"></i>
                                        Edit
                                    </a>
                            </div>`
                    } 
                }
            }
        ]
    });
}

function DeleteUser(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                method: "DELETE",
                success: function (data) {
                    toastr.success(data.message)
                    dataTable.ajax.reload();
                }
            })
        }
    })
}

function LockOrUnlockUser(id) {
    $.ajax({
        method: "POST",
        url: '/Users/LockOrUnlockUserAPI',
        data: JSON.stringify(id),
        contentType: "application/json",
        success: function (data) {
            toastr.success(data.message)
            dataTable.ajax.reload();
        }
    })
}

