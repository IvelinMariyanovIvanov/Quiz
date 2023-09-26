let dataTable;

$(document).ready(function () {
    createQuotesTable();
});

function createQuotesTable() {
    dataTable = $('#usersQuotesTable').DataTable({
        ajax: {
            url: '/Users/GetAllQuotesAPI'
        },
        columns: [
            { data: 'id' },
            { data: 'text' },
            {
                data: 'id',
                render: function (data) {
                    return `<div class="d-flex justify-content-between">
                                    <a href="/Users/AnswerQuote?id=${data} "class="btn btn-outline-primary">
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

