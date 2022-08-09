<template>
  <div class="mp">
    <h1>Motion Picture Application</h1>
    <button v-on:click="createButton" v-show="!showModal ? true : false">Add</button>
    <table class="motionPictureTable" v-show="!showModal ? true : false">
      <tr>
        <th>Name</th>
        <th>Description</th>
        <th>Release Year</th>
        <th>Actions</th>
      </tr>
      <tr v-for="data in result" :key="data.id">
        <td>{{ data.name }}</td>
        <td>{{ data.description }}</td>
        <td>{{ data.releaseYear }}</td>
        <table class = "actionsTable">
          <tr>
            <img class="actions" v-on:click="handleEditClick(); movieToUpdate = data" src="@/assets/editIcon.png" />
            <img class="actions" v-on:click="copyMotionPicture(); movieToUpdate = data" src="@/assets/copyIcon.png" />
            <img class="actions" v-on:click="displayConfirmationModal(); movieToUpdate = data"
              src="@/assets/deleteIcon.png" />
          </tr>
        </table>
      </tr>
    </table>
    <ConfirmationModal :movieToUpdate="movieToUpdate" v-show="confirmationModal == true"
      @cancel-confirmation-modal="closeConfirmationModal" @confirm-cancellation="deleteMotionPicture(movieToUpdate); confirmationModal = false" />

    <form-modal :update="update" :movieToUpdate="movieToUpdate" :showModal="showModal" v-show="showModal"
      @submit-modal="handleChildData($event)" @cancel-modal="closeModal" />




  </div>
</template>


<script>
import FormModal from '@/components/FormModal.vue';
import ConfirmationModal from '@/components/ConfirmationModal.vue';

export default {

  components: {
    FormModal,
    ConfirmationModal,
  },

  mounted() {
    this.getMotionPictures();
  },

  updated() {
    this.getMotionPictures();
  },

  name: 'motion-pictures',

  data() {
    return {
      result: "",
      showModal: false,
      movieToUpdate: {},
      update: false,
      errors: [],
      confirmationModal: false,
    }
  },
  methods: {

    getMotionPictures() {
      fetch("https://localhost:44378/api/MotionPicture", {
        "method": "GET"
      }).then(response => {
        if (response.ok) {
          return response.json();
        }
      }).then(response => {
        this.result = response;
      })
    },

    deleteMotionPicture(data) {
      fetch(`https://localhost:44378/api/MotionPicture/${data.id}`, {
        method: "DELETE"
      }).then(() => alert(`record ${data.name} has been deleted`))
    },

    createNewMotionPicture(motionPicture) {
      this.showModal = false;
      if (this.errors.length) {
        this.showModal = true;
        return;
      }
      fetch("https://localhost:44378/api/MotionPicture", {
        "method": "POST",
        "body": JSON.stringify({
          "name": motionPicture.name,
          "description": motionPicture.description,
          "releaseYear": motionPicture.releaseYear
        }),
        "headers": { 'Content-Type': 'application/json' }
      }).then(response => response.text())
        .then(responseText => {
          alert(responseText)
        })
    },

    updateMotionPicture(motionPicture) {
      this.showModal = false;
      if (this.errors.length) {
        this.showModal = true;
        return;
      }
      fetch("https://localhost:44378/api/MotionPicture", {
        "method": "PUT",
        "body": JSON.stringify({
          "id": motionPicture.id,
          "name": motionPicture.name,
          "description": motionPicture.description,
          "releaseYear": motionPicture.releaseYear
        }),
        "headers": { 'Content-Type': 'application/json' }
      })
        .then(response => response.text())
        .then(responseText => {
          alert(responseText)
        })
      this.update = false;
    },

    copyMotionPicture() {
      this.showModal = true;
    },

    handleChildData(motionPicture) {
      if (this.update) {
        this.updateMotionPicture(motionPicture);
      } else if (!this.update) {
        this.createNewMotionPicture(motionPicture);
      }
    },

    handleEditClick() {
      this.showModal = true;
      this.update = true;
    },

    closeModal() {
      this.showModal = false;
      this.update = false;
    },

  handleCopyClick(motionPicture) {
    this.showModal = true;
    this.createNewMotionPicture(motionPicture);
  },

    createButton() {
      this.showModal = true;
    },

    displayConfirmationModal() {
      this.confirmationModal = true;
    },
    closeConfirmationModal() {
      this.confirmationModal = false;
    }


  },



}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.actions {
  width: 18px;
  height: 18px;
  padding: 4px;
  opacity: 85%;
}

.actionsTable {
  display: flex;
  justify-content: center;
}

.motionPictureTable {
  margin-left: auto;
  margin-right: auto;
}

th {
  border-width: medium;
  border-color: #000;
  border-style: groove;
  width: 25%;
}
td {
  padding: 8px;
}
.mp {
 background-color: rgba(247, 217, 217, 0.623);
 width: 70%;
margin-left: auto;
margin-right: auto;
 color: black;
 border-radius: 35px;
 padding-top: 5px;
 padding-bottom: 5px;

}

</style>
