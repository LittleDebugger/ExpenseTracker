function getExpensesViewModel(){
    const expensesApi = "api/expenses";
    var staticData = {},
        vm = {};

    var editorModal = document.getElementById('editor-modal'),
        expensesGrid = document.getElementById('expenses-grid'),
        $expensesTable = $('#expenses-table'),
        $editorForm = $('#editor-form'),
        $editorModal = $("#editor-modal"),
        dataTableConfig = {
            "paging": true,
            "ordering": true,
            "info": true,
            "lengthChange": false
        };

    class Expense {
        constructor(id, transactionDate, amount, currencyId, recipient, transactionTypeId) {
            this.id = id || 0;
            this.transactionDate = ko.observable(moment(transactionDate).format('YYYY-MM-DD'));
            this.amount = ko.observable(amount || 0);
            this.currencyId = ko.observable(currencyId || 0);
            this.recipient = ko.observable(recipient || '');
            this.transactionTypeId = ko.observable(transactionTypeId || 0);
        }
    }

    $editorForm.submit(function (e) {
        e.preventDefault();
        saveExpense();
        $editorModal.modal('hide');
    });

    function fetchExpenses() {
        $expensesTable.DataTable().clear();
        vm.rows.removeAll();
        dataService.get(expensesApi, function (rows) {
            $expensesTable.DataTable().destroy();
            rows.forEach(function (row) {
                vm.rows.push(row);
            });

            $expensesTable.DataTable(dataTableConfig);
        });
    }

    function saveExpense() {
        vm.rows.removeAll();
        var json = ko.toJSON(vm.editorExpense);

        if (vm.editorIsNewExpense()) {
            dataService.post(expensesApi, json, fetchExpenses, fetchExpenses);
        } else {
            dataService.put(expensesApi, json, fetchExpenses, fetchExpenses);
        }
    }

    function addRow() {
        vm.editorExpense = new Expense();
        openModal();
    }

    function editRow(row) {
        vm.editorExpense = new Expense(
            row.id,
            row.transactionDate,
            row.amount,
            row.currencyId,
            row.recipient,
            row.transactionType);

        openModal();
    }

    function openModal() {
        ko.cleanNode(editorModal);
        ko.applyBindings(vm, editorModal);
        $editorModal.modal();
    }

    function deleteRow(row) {
        vm.rows.removeAll();
        var url = expensesApi + '/' + row.id;
        dataService.delete(url, fetchExpenses, fetchExpenses);
    }

    function staticDataLoaded() {
        vm = {
            rows: ko.observableArray([]),
            availableCurrencies: staticData.Currency,
            availableTransactionTypes: staticData.TransactionType,
            editorExpense: new Expense(),

            getEnumText: function (dataType, id) {
                return staticData[dataType].filter(tt => tt.id == id)[0].value;
            },
            editorIsNewExpense: function () {
                return this.editorExpense.id == 0;
            },
            deleteRow: deleteRow,
            editRow: editRow,
            addRow: addRow
        };

        fetchExpenses();
        ko.applyBindings(vm, expensesGrid);
    }

    staticDataService.getStaticData().then(function (data) {
        staticData = data;
        staticDataLoaded();
    });
}