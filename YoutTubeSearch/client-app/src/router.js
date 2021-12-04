import Vue from "vue";
import Router from "vue-router";
import Home from "./views/Home/Home.vue";
import Video from "./views/Video/Video.vue";
import Channel from "./views/Channel/Channel.vue";

Vue.use(Router);

const router = new Router({
    // mode: "history",
    base: process.env.BASE_URL,
    linkExactActiveClass: "is-active",
    routes: [{
        path: "/",
        name: "Home",
        component: Home,
    },
    {
        path: "/Video",
        name: "Video",
        component: Video,
    },
    {
        path: "/Channel",
        name: "Channel",
        component: Channel,
    }
    ],
});

router.beforeEach((to, from, next) => {
    const publicPages = [
        "Home",
        "Channel",
        "Video",
    ];
    
    next();
});

export default router;