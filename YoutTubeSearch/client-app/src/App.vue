<template>
    <div id="app" ref="appElement">
        <vue-snotify timeout="4000" showProgressBar="true"></vue-snotify>
        
        <div>
            <transition name="slide-fade" mode="out-in">
                <router-view v-on:hideHeaderFooter="hideHeaderFooter"
                             v-on:showHeaderFooter="showHeaderFooter"
                             v-on:logoutUser="logoutUser" />
            </transition>
        </div>
    </div>
</template>
<script>
    export default {
        name: "app",
        components: {
        },
        data() {
            return {
                exibir: false,
                dismissCountDown: 5,
                paddingBottom: String(),
                emAcessoRemoto: false,
                hideHeaderFooterPages: [
                ]
            };
        },
        computed: {
            alert() {
                return this.$store.state.alert;
            }
        },
        beforeMount() {
        },
        methods: {
            hideHeaderFooter() {
                this.exibir = false;
            },
            showHeaderFooter() {
                this.exibir = true;
            },
            adjustFooterPadding(heightFooter) {
                this.paddingBottom = `${heightFooter + 40}px`;
            },
            logoutUser() {
            }
        }
    };
</script>