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
                                    <a onClick=DeleteQuote('/Users/DeleteUserAPI?id=${data}')
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

