import { useLoaderData } from "react-router";
import { TextField, Autocomplete, Button, Stack, Container } from "@mui/material";
import { Save } from "@mui/icons-material";
import { useState } from "react";

export default function EmployeeForm() {
  const [dataLoaded, setDataLoaded] = useState(false)

  const campusList = ["Campus1", "Campus2", "Campus3", "Campus4"]; // useLoaderData()["campuses"];
  const departmentList = ["Department1", "Department2", "Department3", "Department4"]; // useLoaderData()["departments"];

  return (
    <form>
      <Container maxWidth='xs'>
        <Stack
          spacing={4}
          className="FormRowStack"
          sx={{
            justifySelf: 'center',
            justifyContent: 'center',
            alignContent: 'center',
          }}
          >
          <Stack spacing={2} direction="row" className="FormRow">
            <TextField required size="small" id="firstname" label="First Name" variant="filled" />
            <TextField required size="small" id="lastname" label="Last Name" variant="filled" />
          </Stack>
          <Autocomplete className="FormRow"
            size="small"
            aria-required
            disablePortal
            options={campusList}
            sx={{maxWidth: 300}}
            renderInput={(params) => <TextField {...params} label="Campus"/>}
          />
          <Autocomplete className="FormRow"
            size="small"
            aria-required
            disablePortal
            options={departmentList}
            sx={{maxWidth: 300}}
            renderInput={(params) => <TextField {...params} label="Department"/>}
          />
          <Stack
            direction="row"
            spacing={2}
            className="FormSubmitRow"
            sx={{
              paddingTop: '1em',
              justifyContent: 'flex-end'
            }}
            >
            <Button variant="outlined" color="secondary">Cancel</Button>
            <Button
              type="submit"
              variant="contained"
              endIcon={<Save />}
              >
                Save
            </Button>
          </Stack>
        </Stack>
      </Container>
    </form>
  );
}