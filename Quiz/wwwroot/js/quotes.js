let dataTable;

$(document).ready(function () {
    createQuatesTable();
});

function createQuatesTable() {
    dataTable = $('#quotesTable').DataTable({
        ajax: {
            url: '/Quotes/GetAllQuatesApi'
        },
        columns: [
            { data: 'text' },
            { data: 'author.name' },
            {
                data: 'id',
                render: function (data) {
                    return `<div class="d-flex justify-content-around">
                                    <a onClick=DeleteQuote('/Quotes/DeleteQuote?id=${data}')
                                        class="btn btn-outline-danger">
                                        <i class="bi bi-trash3"></i>
                                        Delete
                                    </a>

                                    <a href="/Quotes/EditQuote?id=${data}"
                                        class="btn btn-outline-primary">
                                        <i class="bi bi-pencil-square"></i>
                                        Edit
                                    </a>
                            </div>`
                   
                },
                "with": "25%"
            }
        ]
    });
}
