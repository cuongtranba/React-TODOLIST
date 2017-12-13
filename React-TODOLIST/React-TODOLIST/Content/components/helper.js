class Helper {
    constructor() {

    }
    static FormValidate(attrId) {
        var result = true;
        $('#' + attrId).validator('validate');
        $('#' + attrId + ' .form-group')
            .each(function () {
                if ($(this).hasClass('has-error')) {
                    result = false;
                    return false;
                }
                return false;
            });
        return result;
    }
}
module.exports = Helper