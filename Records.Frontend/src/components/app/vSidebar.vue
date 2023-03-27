<template>
  <div>
    <ul class="sidenav app-sidenav" :class="{ open: isOpen }">
      <router-link
        v-for="link in links"
        :to="link.url"
        :key="link.url"
        :exact="link.exact"
        custom
        v-slot="{ href, navigate, isActive, isExactActive }"
      >
        <li
          :class="[
            isActive && 'router-link-active',
            isExactActive && 'router-link-exact-active',
          ]"
        >
          <a :href="href" @click="navigate" class="waves-effect waves-orange pointer">{{
            link.title
          }}</a>
        </li>
      </router-link>
    </ul>
  </div>
</template>

<script>
export default {
  props: {
    isOpen: {
      type: Boolean,
      default: true,
    },
  },
  data() {
    return {
      links: [
        {
          title: "History",
          url: "/",
          exact: true
        },
        {
          title: "NewRecord",
          url: "/record",
        },
      ],
    };
  },
};
</script>

<style lang="scss">
router-link-active {
  color: red;
}
</style>
