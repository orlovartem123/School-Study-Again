const electives = $.ajax({
    method: "GET",
    url: "/Material/GetElectives",
    success: function (result) {
        return result;
    }
});

function checkIsElectives(value) {
    if (value != -1) {
        isElectives = true;
    } else {
        isElectives = false;
        deleteAllChilds();
    }
}

function getElectivesToSave() {
    if (!isElectives) {
        return;
    }
    let element = document.getElementById('electivesToMaterialsParent');
    let result = {};
    let rows = element.children;
    for (let i = 0; i < rows.length; i++) {
        let selectedId = rows[i].children[1].children[0].value;
        let count = rows[i].children[1].children[1].value;
        if (result[selectedId] === undefined) {
            result[selectedId] = count;
        } else {
            result[selectedId] = Number(count) + Number(result[selectedId]);
        }
    }
    return result;
}


function addElective() {
    if (!isElectives) {
        return;
    }
    let element = document.getElementById('electivesToMaterialsParent');
    if (element.childElementCount === electives.responseJSON.length) {
        return;
    }
    let mainDiv = document.createElement('div');
    mainDiv.classList.add('row');
    mainDiv.setAttribute('style', 'margin-top: 6px;');
    let label = document.createElement('label');
    label.classList.add('col-lg-3');
    let childDiv = document.createElement('div');
    childDiv.classList.add('col-lg-9');
    childDiv.setAttribute('style', 'display:flex;justify-content:space-between;');
    let select = document.createElement('select');
    select.classList.add('form-control');
    electives.responseJSON.forEach(function (item, i, electives) {
        let option = document.createElement('option');
        option.value = item.id;
        option.text = item.name;
        select.options.add(option);
    });
    let inputCount = document.createElement('input');
    inputCount.classList.add('form-control');
    inputCount.setAttribute('required', '');
    inputCount.setAttribute('value', '1');
    inputCount.setAttribute('min', '1');
    inputCount.setAttribute('type', 'number');
    inputCount.setAttribute('style', 'width:80px; margin-left: 6px;');
    let deleteButton = document.createElement('input');
    deleteButton.setAttribute('class', 'btn btn-sm btn-light');
    deleteButton.setAttribute('type', 'button');
    deleteButton.setAttribute('value', '-');
    deleteButton.setAttribute('onclick', 'deleteElective(' + numForChild + ')');
    deleteButton.setAttribute('style', 'width: 50px; margin-left: 6px;');
    childDiv.appendChild(select);
    childDiv.appendChild(inputCount);
    childDiv.appendChild(deleteButton);
    mainDiv.appendChild(label);
    mainDiv.appendChild(childDiv);
    mainDiv.setAttribute('id', childIdPref + numForChild);
    element.appendChild(mainDiv);
    numForChild++;
};

function deleteElective(number) {
    let parent = document.getElementById('electivesToMaterialsParent');
    let elem = document.getElementById(childIdPref + number);
    parent.removeChild(elem);
}

function deleteAllChilds() {
    let parent = document.getElementById('electivesToMaterialsParent');
    let rows = parent.children;
    for (let i = (rows.length - 1); i > 0; i--) {
        let child = rows[i];
        parent.removeChild(child);
    }
}

function getSelectValues(select) {
    let result = [];
    let options = select.options;
    let opt;
    for (var i = 1, iLen = options.length; i < iLen; i++) {
        opt = options[i];

        if (opt.selected) {
            result.push(opt.value);
        }
    }
    return result;
}