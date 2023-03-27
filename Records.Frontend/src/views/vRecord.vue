<template>
  <div>
    <div class="page-title">
      <h3>Новая запись</h3>
    </div>
    <v-loader v-if="loading" />
    <form v-else class="form" @submit.prevent="submitForm">
      <div class="card-content">
        <div class="input-field">
          <select select ref="select" v-model="category">
            <option v-for="c of categories" :key="c.id" :value="c.id">
              {{ c.name }}
            </option>
          </select>
          <label>Выберите категорию</label>
        </div>

        <p>
          <label>
            <input
              class="with-gap"
              name="type"
              type="radio"
              value="income"
              v-model="type"
            />
            <span>Доход</span>
          </label>
        </p>

        <p>
          <label>
            <input
              class="with-gap"
              name="type"
              type="radio"
              value="outcome"
              v-model="type"
            />
            <span>Расход</span>
          </label>
        </p>

        <div class="input-field">
          <input
            id="amount"
            type="number"
            :class="{
              invalid: v$.amount.$error,
            }"
            v-model.number="amount"
          />
          <label for="amount">Сумма</label>
          <span v-if="v$.amount.$error" class="helper-text invalid">{{
            v$.amount.$errors[0].$message
          }}</span>
        </div>

        <div class="input-field">
          <input
            id="description"
            type="text"
            :class="{
              invalid: v$.description.$error,
            }"
            v-model="description"
          />
          <label for="description">Описание</label>
          <span v-if="v$.description.$error" class="helper-text invalid">{{
            v$.description.$errors[0].$message
          }}</span>
        </div>

        <div class="input-field">
          <input
            id="creationDate"
            type="date"
            :class="{
              invalid: v$.description.$error,
            }"
            v-model="creationDate"
          />
          <label for="creationDate">Дата записи</label>
          <span v-if="v$.creationDate.$error" class="helper-text invalid">{{
            v$.creationDate.$errors[0].$message
          }}</span>
        </div>
        <div class="input-field">
          <p>
            <label>
              <input type="checkbox" class="filled-in" v-model="agree" />
              <span>С правилами согласен</span>
            </label>
          </p>

          <span v-if="v$.agree.$error" class="helper-text invalid">{{
            v$.agree.$errors[0].$message
          }}</span>
        </div>
      </div>
      <div class="card-action">
        <div>
          <button class="btn waves-effect waves-light" type="submit">
            Создать
            <i class="material-icons right">send</i>
          </button>
        </div>
      </div>
    </form>
  </div>
</template>

<script>
import { useVuelidate } from "@vuelidate/core";
import { required, helpers } from "@vuelidate/validators";
import vLoader from "@/components/app/vLoader.vue";
import M from "materialize-css";
import { mapActions } from "vuex";

export default {
  name: "v-record",
  components: {
    vLoader,
  },
  setup() {
    return { v$: useVuelidate() };
  },
  data() {
    return {
      loading: true,
      categories: [],
      select: null,
      category: null,
      type: "income",
      amount: 0,
      agree: false,
      description: "",
      creationDate: new Date().toISOString().slice(0, 10),
    };
  },

  methods: {
    ...mapActions(["FETCH_CATEGORIES", "CREATE_RECORD"]),
    async submitForm() {
      this.v$.$validate(); // checks all inputs

      if (!this.v$.$error) {
        await this.CREATE_RECORD({
          categoryId: this.category,
          type: this.type,
          amount: this.amount,
          description: this.description,
          creationDate: this.creationDate,
        });

        this.$message("Запись успешно создана");
        this.v$.$reset();
        this.amount = 0;
        this.description = "";
        this.$router.push({ path: "/" });
      }
    },
  },
  validations() {
    return {
      description: {
        required: helpers.withMessage("Поле обязательно к заполнению", required),
      },
      amount: {
        required: helpers.withMessage("Поле обязательно к заполнению", required),
        minValue: helpers.withMessage(
          "Сумма должна быть положительным числом",
          (value) => value > 0
        ),
      },
      agree: {
        checked: helpers.withMessage(
          "Необходимо согласиться с правилами",
          (value) => value === true
        ),
      },
      creationDate: {
        required: helpers.withMessage("Поле обязательно к заполнению", required),
      },
    };
  },
  async mounted() {
    this.categories = await this.FETCH_CATEGORIES();
    this.loading = false;

    if (this.categories.length) {
      this.category = this.categories[0].id;
    }

    setTimeout(() => {
      this.select = M.FormSelect.init(this.$refs.select);
      M.updateTextFields();
    }, 0);
  },
  unmounted() {
    if (this.select && this.select.destroy) {
      this.select.destroy();
    }
  },
};
</script>
