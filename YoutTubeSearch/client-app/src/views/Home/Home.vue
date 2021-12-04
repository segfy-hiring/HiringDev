<template>
  <div>
    <b-container>
      <b-row class="">
        <div class="header-page mt-5">
          <h2 class="tit-page">YouTube Searcher</h2>
          <p class="txt-page">Welcome to this project</p>
        </div>
      </b-row>
    </b-container>

    <section class="mb-5">
      <b-container>
        <div class="div-table">
          <div class="header-table">

            <div class="">
              <div class="box-filter d-flex">
                <b-form-group>
                  <b-form-input
                  id="title"
                  v-model="title"
                  type="text"
                  required
                  placeholder="Title"></b-form-input>
                </b-form-group>

                <b-form-group>
                  <b-form-select :options="options"
                                          v-model="type"
                                          required
                                          class="w-100 ml-3 input-padrao"></b-form-select>
                </b-form-group>

                <b-form-group class="ml-3">
                  <div class="bt-defaults w-100 ml-3">
                    <button type="button" class="ml-auto" @click="search(true)" variant="primary">Search</button>
                  </div>
                </b-form-group>
              </div>
            </div>
          </div>

          <div class="box-tabel">
            <b-table
              show-empty
              small
              class="table-custom text-center"
              responsive
              :items="items"
              :fields="fields"
              :sort-by.sync="sortBy"
              :sort-desc.sync="sortDesc">
              
              <template v-slot:cell(dateCreated)="data">
                  {{ formatDate(data.value) }}
              </template>

               <template v-slot:cell(actions)="data">
                <b-button
                  size="sm"
                  class="mr"
                  type="button"
                  @click="details(data.item.id, data.item.type)"
                ><font-awesome-icon title="Details" :icon="['fas', 'search-plus']" class="info" /> </b-button>
              </template>
            </b-table>

            <div class="box-pagination">
                <b-pagination v-model="page" :total-rows="total" :per-page="pageSize" class="mr-3"></b-pagination>
                <div class="form-group mb-0">
                    <b-select v-model="pageSize" id="perPageSelect" :options="pageOptions" class=""></b-select>
                </div>
            </div>
          </div>
        </div>

      </b-container>
    </section>
  </div>
</template>
<script src="./Home.js"></script>