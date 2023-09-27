let dataTable;

$(document).ready(function () {
    createUsersTable();
});

function createUsersTable() {
    dataTable = $('#userAchievementsTable').DataTable({
        ajax: {
            url: '/Accounts/GetAllUsersAPI'
        },
        columns: [
            { data: 'fullName' },
            { data: 'email' },
            {
                data: 'id',
                render: function (data) {
                    return `<div class="d-flex justify-content-between">
                                    <a href="/Accounts/UserAchievements?userId=${data} "class="btn btn-outline-primary">
                                        <i class="bi bi-question-square"></i>
                                        Achievements
                                    </a>
                            </div>`
                }
            }
        ]
    });
}

