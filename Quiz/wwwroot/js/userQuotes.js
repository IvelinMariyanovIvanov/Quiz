let dataTable;

$(document).ready(function () {
    createUserQuotesTable();
});

function createUserQuotesTable() {
    dataTable = $('#usersQuotesTable').DataTable({
        ajax: {
            url: '/Questions/GetAllQuestionsAPI'
        },
        columns: [
            { data: 'id' },
            { data: 'text' },
            {
                data: 'id',
                render: function (data) {
                    return `<div class="d-flex justify-content-between">
                                    <a href="/Questions/AnswerQuestion?id=${data} "class="btn btn-outline-primary">
                                        <i class="bi bi-question-square"></i>
                                        Answer
                                    </a>
                            </div>`
                },
                "with": "25%"
            }
        ]
    });
}

