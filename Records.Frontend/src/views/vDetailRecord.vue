<template>
  <div>
    <div>
      <v-loader v-if="loading" />
      <div v-else-if="record">
        <div class="breadcrumb-wrap">
          <router-link to="/" class="breadcrumb">История</router-link>
          <a @click.prevent class="breadcrumb">
            {{ record.type === "income" ? "Доход" : "Расход" }}
          </a>
        </div>
        <div class="row">
          <div class="col s12 m6">
            <div
              class="card"
              :class="{
                green: record.type === 'income',
                red: record.type === 'outcome',
              }"
            >
              <div class="card-content white-text">
                <p>Описание: {{ record.description }}</p>
                <p>Сумма: {{ record.amount }}</p>
                <p>Категория: {{ record.categoryName }}</p>

                <small>{{ $filters.dateFilter(record.creationDate, "datetime") }}</small>
              </div>
            </div>
          </div>
        </div>
      </div>
      <p class="center" v-else>Запись с id ={{ $route.params.id }} не существует.</p>
    </div>
  </div>
</template>

<script>
import vLoader from "@/components/app/vLoader.vue";
import { mapActions } from "vuex";

export default {
  components: {
    vLoader,
  },
  data() {
    return {
      loading: true,
      record: null,
      category: null,
    };
  },
  methods: {
    ...mapActions(["FETCH_RECORD_BY_ID", "FETCH_CATEGORY_BY_ID"]),
  },
  async mounted() {
    const record = await this.FETCH_RECORD_BY_ID(this.$route.params.id);
    this.category = await this.FETCH_CATEGORY_BY_ID(record.categoryId);
    this.loading = false;
    this.record = { ...record, categoryName: this.category.name };
  },
};
</script>
