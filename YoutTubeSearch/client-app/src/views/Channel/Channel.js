import http from "@/_helper/api-services";
import DatePicker from 'vue2-datepicker';

export default {
    data() {
        return {
           channel: {}
        };
    },
    components: {
        DatePicker
    },
    async mounted() {
        await this.getDetails();
    },
    watch: {
       
    },
    methods: {
        async getDetails() {
            this.$loading(true);

            await http.get("/Channel/get/" + this.$route.query.id).then((response) => {
                this.channel = response.data;
                console.log(response.data)
                this.$loading(false);
            },
            error => 
            { 
                this.$snotify.error(error.response.data.message);
                this.$loading(false);
            });
        },
        back()
        {
            window.location.href = "/";
        },
        formatDate(data) {
            let dateTime = new Date(data);
            return dateTime.toLocaleDateString() + ' ' + dateTime.toLocaleTimeString();
        }
    },
};