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
                data: 'id',
                render: function (data) {
                    return `<div class="d-flex justify-content-around">
                                    <a onClick=DeleteUser('/Users/DeleteUserAPI?id=${data}')
                                        class="btn btn-outline-danger">
                                        <i class="bi bi-trash3"></i>
                                        Delete
                                    </a>

                                    <a href="/Users/EditUser?id=${data}"
                                        class="btn btn-outline-primary">
                                        <i class="bi bi-pencil-square"></i>
                                        Edit
                                    </a>
                            </div>` 
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

