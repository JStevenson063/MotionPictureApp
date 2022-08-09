<template>
  <div class="modal-overlay">
    <div class="modal">
      <input type="hidden" v-bind:value="checkMovieToUpdate" />
      <h6>Please provide the following details:</h6>
      <form>

        <label for="name">Motion Picture Name</label><br />
        <input type="text" id="nameField" name="name"
          v-bind:placeholder="update ? movieToUpdate.name : 'Example: Good Fellas'" v-model="motionPicture.name" :class="{'input-error':checkNameField() == true}" />
          <p class = "error" v-show="checkNameField() == true">Name is a required field and cannot exceed 50 characters</p>

        <label for="description" >Description</label><br />
        <input type="text" id="descriptionField" name="description"
          v-bind:placeholder="update ? movieToUpdate.description : 'Optional'" v-model="motionPicture.description" :class="{'input-error': checkDescriptionField() == true}"  />
          <p class = "error" v-show="checkDescriptionField() == true">Description length cannot exceed 500 characters</p>

        <label for="releaseYear">Release Year</label><br />
        <input type="text" id="releaseYearField" name="releaseYear"
          v-bind:placeholder="update ? movieToUpdate.releaseYear : 'Example: 1942'"
          v-model="motionPicture.releaseYear" :class="{'input-error': checkReleaseYearField() == true}" />
          <p class = "error" v-show="checkReleaseYearField() == true">Release Year is a required field that cannot exceed current year and must be in format: 1942</p>
      </form>
      <button type="submit" v-show="update == false" @click="submitModal">Submit</button>
      <button type="submit" v-show="update == true" @click="submitModal">Update</button>
      <button @click="cancelModal">Cancel</button>
    </div>
  </div>
</template>

<script>


export default {
  name: "form-modal",

  data() {
    return {
      motionPicture: {
        name: "",
        description: "",
        releaseYear: "",
      },
      errors: []
    }
  },

  computed: {
    checkMovieToUpdate() {
      if(this.movieToUpdate) {
        this.transferMovieToUpdate();
        return true;
      }
      return false
    }
  },

  methods: {
    submitModal() {
      if (this.movieToUpdate) {
        this.motionPicture.id = this.movieToUpdate.id;
      }
      this.validateForm(this.motionPicture);

      if(this.errors.length == 0) {
      this.$emit("submit-modal", this.motionPicture);
      this.motionPicture.name = "";
      this.motionPicture.description = "";
      this.motionPicture.releaseYear = "";
      }
    },

    cancelModal() {
      this.errors = [];
      this.motionPicture.name = "";
      this.motionPicture.description = "";
      this.motionPicture.releaseYear = "";
      this.$emit("cancel-modal");
    },

    checkNameField() {
      if(this.errors.includes("Name")) {
        return true;
      }
      return false;
    },

    checkReleaseYearField() {
      if(this.errors.includes("Release year") || this.errors.includes("Release year NaN")) {
        return true;
      }
      return false;
    },

    checkDescriptionField() {
      if(this.errors.includes("Description")) {
        return true;
      }
      return false;
    }, 

    transferMovieToUpdate() {
      this.motionPicture.name = this.movieToUpdate.name;
      this.motionPicture.description = this.movieToUpdate.description;
      this.motionPicture.releaseYear = this.movieToUpdate.releaseYear;
    },

    validateForm() {
      this.errors = [];

      if(!this.motionPicture.name || this.motionPicture.name.length > 50) {
        this.errors.push("Name");
      }
      if(!this.motionPicture.releaseYear) {
        this.errors.push("Release year");
      }
      console.log(this.motionPicture.releaseYear);
      console.log(this.motionPicture.releaseYear.toString().length != 4);
      console.log(this.motionPicture.releaseYear.toString().length);

      if(this.motionPicture.releaseYear.toString().length != 4 || isNaN(this.motionPicture.releaseYear) || this.motionPicture.releaseYear > 2022) {
        this.errors.push("Release year NaN");
      }
      if(this.motionPicture.description.length > 500) {
        this.errors.push("Description")
      }

    },

  },
  props: {
    update: Boolean,
    movieToUpdate: Object,
  }

}
</script>
<style scoped>
.modal-overlay {
  position: fixed;
  top: 0;
  bottom: 0;
  left: 0;
  right: 0;
  display: flex;
  justify-content: center;
  background-color: #000000da;
}

.modal {
  text-align: center;
  background-color: white;
  height: 500px;
  width: 500px;
  margin-top: 10%;
  padding: 60px 0;
  border-radius: 20px;
}

h6 {
  font-weight: 500;
  font-size: 28px;
  margin: 20px 0;
}

button {
  background-color: #2e00ac9a;
  width: 150px;
  height: 40px;
  color: white;
  font-size: 14px;
  border-radius: 16px;
  margin-top: 50px;
}
.error {
  color: red;
}

label {
  display:block;
  padding-top: 10px;
  text-align: center;
}

.input-error {
  background-color: rgba(255, 0, 0, 0.267);
}
</style>