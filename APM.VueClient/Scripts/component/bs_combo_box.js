
Vue.component('town-select', {
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
    '<select v-on:click="setData()"  v-bind:value="value" class="form-control" @input="updateValue($event.target.value)">' +
    '<option v-for="town in town_list" v-bind:value="town.id">{{town.name}}</option>' +
    '</select></div>',
    data: {
        town_list: [],
        value: null
    },
    methods: {
        setData: function () {
            this.town_list = towns;
        },
        updateValue(value) {
            this.$emit('input', value);
            this.value = getItemByValue(towns, "id", value);
        }
    },
    beforeMount: function () {
        this.town_list = towns;        
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
    '<label style="margin-right:.5em;margin-left:.5em;" for="vehicle-select">{{ label }}</label>' +
    '<select v-on:click="setData()" v-bind:value="value" class="form-control" @input="updateValue($event.target.value)">' +
    '<option v-for="vehicle in vehicle_list" v-bind:value="vehicle.id">{{vehicle.name}}</option>' +
    '</select></div>',
    data: {
        vehicle_list: [],
        value: null,
        isLoaded: false
    },
    created: function () {
        this.fetchData();
    },
    watch: function() {     
       
    },
    methods: {
        setData: function () {
            this.vehicle_list = vehicles;
        },
        updateValue(value) {
            this.$emit('input', value);
            this.value = getItemByValue(vehicles, "id", value);
        },
        fetchData: function () {
           
        }
    },
    beforeCreate: function () {        
    },
    mounted: function () {                
    },
    beforeMount: function () {
        this.vehicle_list = vehicles;                 
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

            console.log(event.target.value);

        }
    },
    mounted() {
        
      
    }
});