<template>
  <main-layout />
</template>

<script>
import MainLayout from "@/layouts/MainLayout.vue";

export default {
  name: "App",
  components: {
    MainLayout,
  },
};
</script>

<style lang="scss">
@import "materialize-css/dist/css/materialize.min.css";
@import "./assets/styles/index.css";
.active-link {
  color: #42b983;
}

.exact-active-link {
  color: #42b983;
  font-weight: bold;
}
</style>
