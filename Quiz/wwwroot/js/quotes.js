let dataTable;

$(document).ready(function () {
    createQuotesTable();
});

function createQuotesTable() {
    dataTable = $('#quotesTable').DataTable({
        ajax: {
            url: '/Quotes/GetAllQuotesAPI'
        },
        columns: [
            { data: 'text' },
            { data: 'author.name' },
            {
                data: 'id',
                render: function (data) {
                    return `<div class="d-flex justify-content-around">
                                    <a onClick=DeleteQuote('/Quotes/DeleteQuoteAPI?id=${data}')
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
                }
            }
        ]
    });
}

function DeleteQuote(url) {
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
