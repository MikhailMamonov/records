<template>
  <div>
    <vLoader v-if="loading" />
    <div class="app-main-layout" v-else>
      <v-navbar/>
      <v-sidebar :isOpen="isOpen" ></v-sidebar>

      <main class="app-content" :class="{ full: !isOpen }">
        <div class="app-page">
          <router-view></router-view>
        </div>
      </main>

      <div class="fixed-action-btn">
        <router-link
          to="/record"
          class="btn-floating btn-large blue"
          href="#"
          v-tooltip="'Создать новую запись'"
        >
          <i class="large material-icons">add</i>
        </router-link>
      </div>
    </div>
  </div>
</template>

<script>
import vLoader from "@/components/app/vLoader.vue";
import vSidebar from "@/components/app/vSidebar.vue";
import vNavbar from '@/components/app/vNavbar.vue';
import { mapGetters } from "vuex";

export default {
  name: "main-layout",
  components: {
    vSidebar,
    vLoader,
    vNavbar
  },
  data() {
    return {
      isOpen: true,
      loading: true,
    };
  },
  computed: {
    ...mapGetters([ "ERROR"]),
  },
  watch: {
    error(fbError) {
       alert("Что-то пошло не так", fbError);
    },
  },
  async mounted() {
    this.loading = false;
  },
};
</script>
