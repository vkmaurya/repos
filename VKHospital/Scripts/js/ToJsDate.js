
function ToJsDate(value) {
    if (value == null) {
        return "";
    }
    else {
        if (value != '') {
            var pattern = /Date\(([^)]+)\)/;
            var result = pattern.exec(value);
            var dt = new Date(parseFloat(result[1]));
            return (dt.getMonth() + 1) + "/" + dt.getDate() + "/" + dt.getFullYear();
        }
        else {
            return "";
        }
    }

}

