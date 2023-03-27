import "materialize-css/dist/js/materialize.min";

import App from "./App.vue";
import { createApp } from "vue";
import filters from "./helpers/filters";
import messagePlugin from "./utils/message.plugin";
import router from "./router";
import store from "./store";

let app = createApp(App).use(messagePlugin).use(store).use(router)
app.config.globalProperties.$filters = filters;
app.mount("#app");
