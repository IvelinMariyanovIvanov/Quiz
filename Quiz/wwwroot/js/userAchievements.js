let dataTable;

$(document).ready(function () {
    createTable();
});

function createTable() {
    dataTable = $('#usersAchievementsTable').DataTable({
        ajax: {
            url: '/Accounts/GetUserAchievementsAPI/'
        },
        columns: [
            { data: 'fullName' },
            { data: 'email' }
        ]
    });
}

