import http from "@/_helper/api-services";
import DatePicker from 'vue2-datepicker';

export default {
    data() {
        return {
           video: {}
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

            await http.get("/Video/get/" + this.$route.query.id).then((response) => {
                this.video = response.data;

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