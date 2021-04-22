
/*
 * Base Entity Class
 */

public class Entity
{

    int ID;
    public EntityLink myLink;
    public EntityBrain myBrain;
    int Direction;
    bool engaged;
    public bool removed = false;
    Entity interactor;
    public Entity ()
    {
        myLink = new EntityLink();
        myBrain = new EntityBrain(myLink, this);
   
    }


    public void EstablishLink(EntityLink link)
    {
        myLink = link;
    }

    public EntityLink GetLink()
    {
        return myLink;
    }
    public void GiveBrain(EntityBrain b)
    {
        myBrain = b;
    }
    public EntityBrain GetBrain()
    {
        return myBrain;
    }

    public void EngageWith(Entity e)
    {
        interactor = e;
        engaged = true;
    }
    public void disengage()
    {
        interactor = null;
        engaged = false;
    }
}
