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
    '<label style="margin-right:.5em;margin-left:.5em;" for="town-select">{{ label }}</label>' +
    '<select v-bind:value="value" class="form-control" @input="updateValue($event.target.value)">' +
    '<option v-for="cost_type in cost_type_list" v-bind:value="cost_type.id">{{cost_type.description}}</option>' +
    '</select></div>',
    data: {
        town_list: null,
        value: null
    },
    methods: {
        updateValue(value) {
            this.$emit('input', value);
            this.value = value;
        }
    },
    beforeMount: function () {
        this.currency_list = currecy_list;
    }
});