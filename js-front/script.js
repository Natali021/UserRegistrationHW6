(function(){
    var app = {
        initialize : function(){
            this.setUpListeners();
        },

        setUpListeners:function(){
            $('form').on('submit', app.submitForm);
            $('form').on('keydown', 'input', app.removeError);
        },

        submitForm:function(e){
            e.preventDefault();

            var form = $(this),
                submitBtn = form.find('button[type="submit"]');

            if(app.validateForm(form) === false) return false;
                submitBtn.attr('disabled', 'disabled');

            let context = form.attr('context');

            //викликаємо методи
            if(context == "reg"){
                app.ajaxReg(form);
            }else if(context == "auth"){
                app.ajaxAuth(form);
            }else if(context == "removePas"){
                app.ajaxRemovePas(form);
            }

        },

        //реєстрація    https://localhost:7276/User/AddUser
        ajaxReg:function(form){
            let User = {
                Id: 0,
                UserFullName: form.find('input[name="userFullName"]').val(),
                UserLogin: form.find('input[name="login"]').val(),
                UserPassword: form.find('input[name="password"]').val(),
                Role: form.find('input[name="role"]').val()
                };
                  
            let json = JSON.stringify(User);

            $.ajax({
                url:'https://localhost:7276/User/AddUser',
                type: form.attr('method'),
                contentType: "application/json; charset=utf-8",
                data:json
            })
            .done(function(msg){
                if(msg === 200){
                    var result = "<div = 'bg-success'>Ви вдало зареєструвалися!</div>"
                    form.html(result);
                }else{
                    form.html(msg);
                }
            })
            .fail(function(msg){
                console.log(msg)
            })
        },

        //авторизація   https://localhost:7276/User/AuthorizationUser?login=Vanya&password=12356
        ajaxAuth:function(form){
            $.ajax({
                url:`https://localhost:7276/User/AuthorizationUser?login=${form.find('input[name="login"]').val()}&password=${form.find('input[name="password"]').val()}`,
                type: form.attr('method'),
            })
            .done(function(msg){
                if(msg === 200){
                    var result = "<div = 'bg-success'>Ви вдало авторизувалися!</div>"
                    form.html(result);
                }else{
                    form.html(msg);
                }
            })
            .fail(function(msg){
                console.log(msg)
            })
        },

        //зміна паролю    https://localhost:7276/User/UpdatePassword?login=Vanya&password=12356&newPassword=1234
        ajaxRemovePas:function(form){
            $.ajax({
                url:`https://localhost:7276/User/UpdatePassword?login=${form.find('input[name="login"]').val()}&password=${form.find('input[name="password"]').val()}&newPassword=${form.find('input[name="newPassword"]').val()}`,
                type: form.attr('method'),
            })
            .done(function(msg){
                if(msg === 200){
                    var result = "<div = 'bg-success'>Ви вдало змінили пароль!</div>"
                    form.html(result);
                }else{
                    form.html(msg);
                }
            })
            .fail(function(msg){
                console.log(msg)
            })
        },

        //валідація
        validateForm:function(form){
            var inputs = form.find('input'),
            valid = true;

            inputs.tooltip('dispose');
            
            $.each(inputs, function(index, val){
                var input = $(val),
                    val = input.val(),
                    formGroup = input.parents('.form-group'),
                    label = formGroup.find('label').text().toLowerCase(),
                    textError = 'Не вірно введений ' + label;

                if(val.length <= 3 & label != 'роль'){
                    input.addClass('is-invalid').removeClass('is-valid')
                    input.tooltip({
                        trigger:'manual',
                        placement: 'right',
                        title: textError
                    }).tooltip('show');   
                    valid = false; 
                } else if(val.length === 0 & label === 'роль'){
                    input.addClass('is-invalid').removeClass('is-valid')
                    input.tooltip({
                        trigger:'manual',
                        placement: 'right',
                        title: textError
                    }).tooltip('show');   
                    valid = false; 
                }else{
                    input.addClass('is-valid').removeClass('is-invalid')
                }
            })
            
            return valid;
        },

        removeError:function(){
            $(this).tooltip('dispose').removeClass('is-invalid');
        }
    }

    app.initialize();

}());