import http from "@/_helper/api-services";
import DatePicker from 'vue2-datepicker';

export default {
    data() {
        return {
            fields: [
                {
                    key: "youtubeId",
                    label: "Youtube Id",
                    sortable: false,
                    thClass: 'text-center',
                    tdClass: 'text-left',
                },
                {
                    key: "name",
                    label: "Title",
                    sortable: false,
                    thClass: 'text-center',
                    tdClass: 'text-left',
                },
                {
                    key: "type",
                    label: "Type",
                    sortable: false,
                    thClass: 'text-center',
                    tdClass: 'text-center',
                },
                {
                    key: "dateCreated",
                    label: "Created At",
                    sortable: false,
                    thClass: 'text-center',
                    tdClass: 'text-left',
                },
                {
                    key: "actions",
                    label: "",
                    sortable: false,
                    thClass: 'text-center',
                    tdClass: 'text-center',
                },
            ],
            type: null,
            title: String(),
            sortBy: this.ordenacaoPor,
            sortDesc: true,
            options: [
                { value: null, text: "All" },
                { value: 0, text: "Videos" },
                { value: 1, text: "Channels" },
            ],
            page: 1,
            pageSize: 10,
            total: 0,
            pageOptions: [
                { value: 10, text: "10" },
                { value: 25, text: "25" },
                { value: 50, text: "50" }
            ],
            items: []
        };
    },
    components: {
        DatePicker
    },
    mounted() {
    },
    watch: {
        pageSize() {
            this.page = 1;
            this.search();
        },
        page() {
            this.search();
        },
    },
    methods: {
        async search(reset) {
            this.$loading(true);

            if(reset)
                this.page = 1;

            var config = {
                params: {
                    name: this.title,
                    type: this.type,
                    page: this.page,
                    PageSize: this.pageSize
                }
            };

            await http.get("/search/get", config).then((response) => {
                this.total = response.data.total;
                this.items = response.data.results;

                this.$loading(false);
            },
            error => 
            { 
                this.$snotify.error(error.response.data.message);
                this.$loading(false);
            });
        },
        details(id, type)
        {
            let url = '/#/';

            if(type == 'CHANNEL')
                url += 'Channel/?id=' + id;
            else
                url += 'Video/?id=' + id;

            window.location.href = url;
        },
        formatDate(data) {
            let dateTime = new Date(data);
            return dateTime.toLocaleDateString() + ' ' + dateTime.toLocaleTimeString();
        }
    },
};