import { createRouter, createWebHistory } from "vue-router";

const routes = [
  {
    path: "/",
    name: "home",
    component: () => import("../views/vHistory.vue"),
  },
  {
    path: "/detail/:id",
    name: "detail",
    component: () => import("../views/vDetailRecord.vue"),
  },
  {
    path: "/record",
    name: "record",
    component: () => import("../views/vRecord.vue"),
  },
];

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes,
  linkActiveClass: "router-link-active",
  linkExactActiveClass: "router-link-active",
});

export default router;
