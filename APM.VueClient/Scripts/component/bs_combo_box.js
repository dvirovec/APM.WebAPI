
Vue.component('cost-type-select', {
    props: {
        value: {
            required: true
        },
        label: {
            type: String,
            required: true
        },
        required: {
            type: Boolean
        },
        readonly: {
            type: Boolean
        }
    },
    template: '<div class="form-inline col-sx-6">' +
    '<label style="margin-right:.5em;margin-left:.5em;" for="select">{{ label }}</label>' +
    '<select name="select" v-bind:value="value" class="form-control" @input="updateValue($event.target.value)">' +
    '<option v-for="d in data_list" v-bind:value="d.id">{{d.name}}</option>' +
    '</select></div>',
    data: {
        data_list: [],
        value: null
    },
    methods: {        
        updateValue(value) {
            this.$emit('input', value);
            this.value = value;
        }
    },
    beforeMount: function () {
        this.data_list = cost_type_list;
    }
});



Vue.component('town-select-from', {
    props: {
        value: {
            required: true
        },
        label: {
            type: String,
            required: true
        },
        required: {
            type: Boolean
        },
        readonly: {
            type: Boolean
        }
    },

    template: '<div class="form-inline col-sx-6">' +
    '<label style="margin-right:.5em;margin-left:.5em;" for="select">{{ label }}</label>' +
    '<select name="select" v-bind:value="value" class="form-control" @input="updateValue($event.target.value)">' +
    '<option v-for="d in data_list" v-bind:value="d.id">{{d.name}}</option>' +
    '</select></div>',
    data: {
        data_list: [],
        value: null
    },
    methods: {        
        updateValue(value) {
            this.$emit('input', value);
            this.value = value;
        }
    },
    beforeMount: function () {
        this.data_list = towns;        
    }
});

Vue.component('vehicle-select', {
    props: {
        value: {
            required: true
        },
        label: {
            type: String,
            required: true
        },
        required: {
            type: Boolean
        },
        readonly: {
            type: Boolean
        }
    },

    template: '<div class="form-inline col-sx-6" >' +
    '<label style="margin-right:.5em;margin-left:.5em;" for="select">{{ label }}</label>' +
    '<select name="select" v-bind:value="value" class="form-control" @input="updateValue($event.target.value)">' +
    '<option v-for="d in data_list" v-bind:value="d.id">{{d.name}}</option>' +
    '</select></div>',
    data: {
        data_list: [],
        value: null        
    },
    methods: {        
        updateValue(value) {
            this.$emit('input', value);
            this.value = value;
        }        
    },    
    beforeMount: function () {
        this.data_list = vehicles;                 
    }    
});


Vue.component('datetimepicker', {
    template: "<input  type='datetime-local' class='form-control' :value='value' @change='update($event)' /> \
                <span class='input-group-addon'> \
                    <span class='glyphicon glyphicon-calendar'></span> \
                </span>",
    props: ['value'],
    methods: {
        update(event) {

            this.$emit('input', event.target.value);
           
        }
    },
    mounted() {
        
      
    }
});