function getMultipleValues(select) {
    let result = [];
    let options = select && select.options;
    let opt;

    for (var i = 0; i < options.length; i++) {
        opt = options[i];

        if (opt.selected) {
            result.push(opt.value);
        }
    }
    return result;
}